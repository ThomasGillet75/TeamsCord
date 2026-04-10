#extension GL_OES_standard_derivatives : enable
precision mediump float;

uniform vec2 u_resolution;
uniform vec2 u_mouse;

void main() {
  vec2 uv = gl_FragCoord.xy / u_resolution;
  float grid = 20.0;
  vec2 gv = fract(uv * grid);
  vec2 id = floor(uv * grid);

  // Base gap in pixels
  float gapPx = 20.0;
  vec2 gap = clamp((gapPx * grid) / u_resolution, vec2(0.0), vec2(0.9));
  gv = gv * (1.0 - gap) + gap * 0.5;
  vec2 center = (id + 0.5) / grid;
  float d = distance(center, u_mouse);
  float influence = smoothstep(0.20, 0.0, d);

  // Rounded square SDF + circle SDF with the same nominal size.
  float radius = 0.07;
  vec2 q = abs(gv - 0.5) - vec2(0.23 - radius);
  float roundedSquare = length(max(q, 0.0)) + min(max(q.x, q.y), 0.0) - radius;
  float circle = length(gv - 0.5) - 0.23;
  float shape = mix(roundedSquare, circle, influence);

  float aa = max(fwidth(shape), 0.001);
  float mask = 1.0 - smoothstep(0.0, aa, shape);

  //color
  vec3 bg = vec3(72.0/255.0, 88.0/255.0, 154.0/255.0); //blue => #48589a
  vec3 fg = vec3(48.0/255.0, 52.0/255.0, 70.0/255.0); //Background Color
  vec3 color = mix(bg, fg, mask);

  gl_FragColor = vec4(color, 1.0);
}
