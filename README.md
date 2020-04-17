Lab2:

1. https://drive.google.com/file/d/1jm5tZwvc1yi4kVafbkX5BaZ12XC7s1iX/view?usp=sharing

2. ![](lab2/CatBunnyScrsht.png)

Lab3:

1.https://drive.google.com/open?id=1qJvG1p790rMQZbRrcGMnlnbkHe5YLtrI

2. Description of materials:\n
  a. Cube on the bottom left: This is a phong material with a specular highlight of green, from the Three.js default shaders/materials\n
  b. Torus knot in the center: this is the lab's provided fragment shader that changes the rgb value of the color based on the two provided colors and the z position of the current fragment\n
  c. The top right torus knot: Another one of the Three.js provided shaders, this is a toon shader with a specular highlight in white\n
  d. The orbiting torus knot: My custom shader, which uses the elapsed time since the program started as a uniform variable to change the color as the sin/cos of time (specifically: R = sin(-time) G = cos(time) B = sin^2(time)).\n
