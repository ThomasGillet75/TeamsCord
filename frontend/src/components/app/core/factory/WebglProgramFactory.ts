import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class WebglProgramFactory {

  private compileShader(gl: WebGLRenderingContext,type: GLenum, source: string): WebGLShader {
    const shader: WebGLShader | null = gl.createShader(type);
    if (!shader) throw new Error('Failed to create shader');

    gl.shaderSource(shader, source);
    gl.compileShader(shader);

    const isCompiled: boolean = gl.getShaderParameter(shader, gl.COMPILE_STATUS);
    if (!isCompiled) {
      const info: string = gl.getShaderInfoLog(shader) ?? 'Unknown shader compile error';
      gl.deleteShader(shader);
      throw new Error(`Shader compilation failed: ${info}`);
    }
    return shader;
  }

  public createProgramFromSource(
    gl: WebGLRenderingContext,
    vertexSource: string,
    fragmentSource: string
  ): WebGLProgram {
    const vertexShader: WebGLShader = this.compileShader(gl, gl.VERTEX_SHADER, vertexSource);
    const fragmentShader: WebGLShader = this.compileShader(gl, gl.FRAGMENT_SHADER, fragmentSource);

    try {
      return this.linkProgram(gl, vertexShader, fragmentShader);
    } finally {
      gl.deleteShader(vertexShader);
      gl.deleteShader(fragmentShader);
    }
  }

  private linkProgram(
    gl: WebGLRenderingContext,
    vertexShader: WebGLShader,
    fragmentShader: WebGLShader
  ): WebGLProgram {
    const program: WebGLProgram | null = gl.createProgram();
    if (program === null) {
      throw new Error('Unable to create WebGL program');
    }

    gl.attachShader(program, vertexShader);
    gl.attachShader(program, fragmentShader);
    gl.linkProgram(program);

    const isLinked: boolean = gl.getProgramParameter(program, gl.LINK_STATUS) as boolean;
    if (!isLinked) {
      const info: string = gl.getProgramInfoLog(program) ?? 'Unknown program link error';
      gl.deleteProgram(program);
      throw new Error(`Program link failed: ${info}`);
    }

    return program;
  }
}
