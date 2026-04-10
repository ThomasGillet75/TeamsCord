import {Component, ElementRef, ViewChild} from '@angular/core';

@Component({
  selector: 'tc-background-shader',
  imports: [],
  templateUrl: './background-shader.html',
  styleUrl: './background-shader.css',
})
export class BackgroundShader {
  @ViewChild('shaderCanvas', { static: true })
  private canvasRef!: ElementRef<HTMLCanvasElement>;

  private gl: WebGLRenderingContext | null = null;
  private program: WebGLProgram | null = null;
  private uResolution: WebGLUniformLocation | null = null;
  private uMouse: WebGLUniformLocation | null = null;
  private mouse = { x: 0.5, y: 0.5 };

  async ngAfterViewInit(): Promise<void> {
    await this.shaderInit();
  }

  //To Do: Refactor hehe
  private async shaderInit(): Promise<void> {
    const canvas = this.canvasRef.nativeElement;
    const gl = canvas.getContext('webgl');

    if (!gl) {
      console.error('WebGL not supported');
      return;
    }
    this.gl = gl;
    const derivatives = gl.getExtension('OES_standard_derivatives');
    if (!derivatives) {
      console.error('OES_standard_derivatives non supportée sur ce device/browser');
      return;
    }

    const vertexSource = await fetch('/assets/shaders/square-to-circle.vert').then((r) => r.text());
    const fragmentSource = await fetch('/assets/shaders/square-to-circle.frag').then((r) => r.text());

    const vertexShader = this.compile(gl.VERTEX_SHADER, vertexSource);
    const fragmentShader = this.compile(gl.FRAGMENT_SHADER, fragmentSource);
    if (!vertexShader || !fragmentShader) return;

    const program = gl.createProgram();
    if (!program) {
      console.error('createProgram failed');
      return;
    }
    this.program = program;

    gl.attachShader(program, vertexShader);
    gl.attachShader(program, fragmentShader);
    this.gl.linkProgram(program);
    this.program = program;

    if(!this.gl.getProgramParameter(program, this.gl.LINK_STATUS)) {
      console.error(this.gl.getProgramInfoLog(program));
    }

    this.gl.useProgram(program);

    const buffer = gl.createBuffer();
    if (!buffer) {
      console.error('createBuffer failed');
      return;
    }
    this.gl.bindBuffer(this.gl.ARRAY_BUFFER, buffer);
    this.gl.bufferData(this.gl.ARRAY_BUFFER, new Float32Array([
      -1, -1,
      1, -1,
      -1,  1,
      1,  1
    ]), this.gl.STATIC_DRAW);

    const position = this.gl.getAttribLocation(program, "position");
    this.gl.enableVertexAttribArray(position);
    this.gl.vertexAttribPointer(position, 2, this.gl.FLOAT, false, 0, 0);

    this.uResolution = gl.getUniformLocation(program, "u_resolution");
    this.uMouse = gl.getUniformLocation(program, "u_mouse");

    window.addEventListener('mousemove', (event: MouseEvent) => {
      const rect = canvas.getBoundingClientRect();
      this.mouse.x = (event.clientX - rect.left) / rect.width;
      this.mouse.y = 1 - (event.clientY - rect.top) / rect.height;
    });

    this.resizeCanvas();
    requestAnimationFrame(() => this.render());
  }

  render() {
    if (!this.gl || !this.program) return;

    const gl = this.gl;
    gl.useProgram(this.program);
    this.resizeCanvas();

    gl.viewport(0, 0, gl.canvas.width, gl.canvas.height);

    if (this.uResolution && this.uMouse) {
      this.gl.uniform2f(this.uResolution, this.gl.canvas.width, this.gl.canvas.height);
      this.gl.uniform2f(this.uMouse, this.mouse.x, this.mouse.y);

    }
    this.gl.drawArrays(this.gl.TRIANGLE_STRIP, 0, 4);
    requestAnimationFrame(() => this.render());
  }

  private resizeCanvas(): void {
    if (!this.gl) return;
    const canvas = this.gl.canvas as HTMLCanvasElement;
    const dpr = window.devicePixelRatio || 1;
    const width = Math.floor(canvas.clientWidth * dpr);
    const height = Math.floor(canvas.clientHeight * dpr);

    if (canvas.width !== width || canvas.height !== height) {
      canvas.width = width;
      canvas.height = height;
    }
  }

  private compile(type: GLenum, source: string): WebGLShader | null {
    if (!this.gl) return null;

    const shader = this.gl.createShader(type);
    if (!shader) return null;

    this.gl.shaderSource(shader, source);
    this.gl.compileShader(shader);

    if (!this.gl.getShaderParameter(shader, this.gl.COMPILE_STATUS)) {
      console.error(this.gl.getShaderInfoLog(shader));
      this.gl.deleteShader(shader);
      return null;
    }

    return shader;
  }
}
