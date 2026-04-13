precision mediump float;

  uniform vec2 u_resolution;
  uniform vec2 u_mouse;

  const vec3 COLOR_BACKGROUND = vec3(72.0 / 255.0, 88.0 / 255.0, 154.0 / 255.0);
  const vec3 COLOR_SHAPE = vec3(48.0 / 255.0, 52.0 / 255.0, 70.0 / 255.0);

  vec2 toAspectCorrectedSpace(vec2 normalizedCoord, float aspectRatio) {
    return vec2((normalizedCoord.x - 0.5) * aspectRatio + 0.5, normalizedCoord.y);
  }

  float computeGridCellCount(float smallestScreenDimensionPx) {
    return clamp(floor(smallestScreenDimensionPx / 72.0), 8.0, 22.0);
  }

  float computeGapRatioInCell(float cellSizePx) {
    float gapSizePx = clamp(cellSizePx * 0.22, 6.0, 18.0);
    return clamp(gapSizePx / cellSizePx, 0.08, 0.45);
  }

  float signedDistanceRoundedBox(vec2 centeredLocalCoord, vec2 halfExtents, float cornerRadius) {
    vec2 distanceToEdges = abs(centeredLocalCoord) - (halfExtents - vec2(cornerRadius));
    return length(max(distanceToEdges, 0.0)) + min(max(distanceToEdges.x, distanceToEdges.y), 0.0) - cornerRadius;
  }

  float computeMouseInfluence(vec2 gridCellIndex, float gridCellCount, vec2 aspectCorrectedMouseCoord) {
    vec2 gridCellCenter = (gridCellIndex + 0.5) / gridCellCount;
    float distanceToMouse = distance(gridCellCenter, aspectCorrectedMouseCoord);
    return smoothstep(0.20, 0.0, distanceToMouse);
  }

  float computeShapeSignedDistance(vec2 localCellCoord, float shapeHalfSize, float morphInfluence) {
    vec2 centeredLocalCoord = localCellCoord - 0.5;
    float roundedCornerRadius = shapeHalfSize * 0.24;

    float roundedSquareDistance = signedDistanceRoundedBox(
      centeredLocalCoord,
      vec2(shapeHalfSize),
      roundedCornerRadius
    );
    float circleDistance = length(centeredLocalCoord) - shapeHalfSize;

    return mix(roundedSquareDistance, circleDistance, morphInfluence);
  }

  void main() {
    vec2 normalizedFragmentCoord = gl_FragCoord.xy / u_resolution;
    float viewportAspectRatio = u_resolution.x / u_resolution.y;

    vec2 aspectCorrectedFragmentCoord = toAspectCorrectedSpace(normalizedFragmentCoord, viewportAspectRatio);
    vec2 aspectCorrectedMouseCoord = toAspectCorrectedSpace(u_mouse, viewportAspectRatio);

    float smallestScreenDimensionPx = min(u_resolution.x, u_resolution.y);
    float gridCellCount = computeGridCellCount(smallestScreenDimensionPx);

    vec2 gridSpaceCoord = aspectCorrectedFragmentCoord * gridCellCount;
    vec2 localCellCoord = fract(gridSpaceCoord);
    vec2 gridCellIndex = floor(gridSpaceCoord);

    float cellSizePx = smallestScreenDimensionPx / gridCellCount;
    float gapRatioInCell = computeGapRatioInCell(cellSizePx);

    localCellCoord = localCellCoord * (1.0 - gapRatioInCell) + gapRatioInCell * 0.5;

    float morphInfluence = computeMouseInfluence(gridCellIndex, gridCellCount, aspectCorrectedMouseCoord);

    float shapeHalfSize = 0.5 - gapRatioInCell * 0.5 - 0.02;
    shapeHalfSize = clamp(shapeHalfSize, 0.10, 0.45);

    float shapeSignedDistance = computeShapeSignedDistance(localCellCoord, shapeHalfSize, morphInfluence);

    float antiAliasWidth = max(1.5 / cellSizePx, 0.001);
    float shapeMask = 1.0 - smoothstep(0.0, antiAliasWidth, shapeSignedDistance);

    vec3 finalColor = mix(COLOR_BACKGROUND, COLOR_SHAPE, shapeMask);
    gl_FragColor = vec4(finalColor, 1.0);
  }
