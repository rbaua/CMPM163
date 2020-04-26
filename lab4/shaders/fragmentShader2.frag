varying vec3 vUv;
uniform vec3 colorA;
uniform vec3 colorB;
uniform float time;

void main() {
  gl_FragColor = vec4(sin(-time) + 1.0, cos(time) + 1.0, (sin(time) * sin(time)) + 1.0 , 1.0);
}

