varying vec2 vUv;
uniform vec3 colorA;
uniform vec3 colorB;

void main() {
  gl_FragColor = texture2D(texture1, vUv);
}

