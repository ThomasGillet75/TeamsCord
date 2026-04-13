import {Component, ElementRef, inject, ViewChild} from '@angular/core';
import {WebglProgramFactory} from '../factory/WebglProgramFactory';

@Component({
  selector: 'tc-background-shader',
  imports: [],
  templateUrl: './background-shader.html',
  styleUrl: './background-shader.css',
})
export class BackgroundShader {
  @ViewChild('shaderCanvas', { static: true })
  private canvasRef!: ElementRef<HTMLCanvasElement>;
  private uResolution: WebGLUniformLocation | null = null;
  private uMouse: WebGLUniformLocation | null = null;
  private mouse = { x: 0.5, y: 0.5 };
  private vertexPath:string = "/assets/shaders/square-to-circle.vert"
  private fragmentPath:string = "/assets/shaders/square-to-circle.frag"
  private webglProgramFactory = inject(WebglProgramFactory);

  async ngAfterViewInit(): Promise<void> {
    await this.shaderInit();
  }

  private async shaderInit(): Promise<void> {
    const canvas: HTMLCanvasElement = this.canvasRef.nativeElement;
    let gl : WebGLRenderingContext = this.initGl(canvas);
    const vertexSource: string = await fetch(this.vertexPath).then((r) => r.text());
    const fragmentSource: string = await fetch(this.fragmentPath).then((r) => r.text());
    const program:WebGLProgram = this.webglProgramFactory.createProgramFromSource(gl,vertexSource, fragmentSource);
    gl.useProgram(program);
    gl = this.initBuffer(gl);
    this.initPositionHandler(gl, program);
    this.initEventListener(canvas);
    this.resizeCanvas(gl);
    requestAnimationFrame(() => this.render(program, gl));
  }

  private initGl(canvas: HTMLCanvasElement):WebGLRenderingContext{
    const gl : WebGLRenderingContext | null = canvas.getContext('webgl');

    if (gl == null) {
      throw new Error('WebGL not supported');
    }
    gl.getExtension('OES_standard_derivatives');
    return gl;
  }

  private initPositionHandler(gl:WebGLRenderingContext, program: WebGLProgram): void {
    const position = gl.getAttribLocation(program, "position");
    gl.enableVertexAttribArray(position);
    gl.vertexAttribPointer(position, 2, gl.FLOAT, false, 0, 0);

    this.uResolution = gl.getUniformLocation(program, "u_resolution");
    this.uMouse = gl.getUniformLocation(program, "u_mouse");
  }

  private initEventListener(canvas: HTMLCanvasElement): void {
    window.addEventListener('mousemove', (event: MouseEvent) => {
      const rect = canvas.getBoundingClientRect();
      this.mouse.x = (event.clientX - rect.left) / rect.width;
      this.mouse.y = 1 - (event.clientY - rect.top) / rect.height;
    });
  }

  private initBuffer(gl: WebGLRenderingContext): WebGLRenderingContext{
    const buffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array([
      -1, -1,
      1, -1,
      -1,  1,
      1,  1
    ]), gl.STATIC_DRAW);
    return gl;
  }

  private render(program : WebGLProgram, gl :WebGLRenderingContext ): void {
    if (!gl || !program) return;

    gl.useProgram(program);
    this.resizeCanvas(gl);

    gl.viewport(0, 0, gl.canvas.width, gl.canvas.height);

    if (this.uResolution && this.uMouse) {
      gl.uniform2f(this.uResolution, gl.canvas.width, gl.canvas.height);
      gl.uniform2f(this.uMouse, this.mouse.x, this.mouse.y);

    }
    gl.drawArrays(gl.TRIANGLE_STRIP, 0, 4);
    requestAnimationFrame(() => this.render(program, gl));
  }

  private resizeCanvas(gl: WebGLRenderingContext): void {
    if (!gl) return;
    const canvas = gl.canvas as HTMLCanvasElement;
    const dpr = window.devicePixelRatio || 1;
    const width = Math.floor(canvas.clientWidth * dpr);
    const height = Math.floor(canvas.clientHeight * dpr);

    if (canvas.width !== width || canvas.height !== height) {
      canvas.width = width;
      canvas.height = height;
    }
  }
}
