int gridSize = 32; // Size of each grid cell
int gridCount = 8; // The grid will be 16x16 cells

void setup() {
  // Size * Count
  size(32 * 8, 32 * 8); // Create a window large enough to hold the entire grid
  background(255); // Set the background color to white
  stroke(0); // Set the line color to black
  
  for (int i = 0; i < gridCount; i++) {
    for (int j = 0; j < gridCount; j++) {
      int x = i * gridSize;
      int y = j * gridSize;
      rect(x, y, gridSize, gridSize);
    }
  }
}

void draw()
{
  // Nothing
}

void keyPressed() {
  if (key == ' ') { // Check if the spacebar is pressed
    // Save the frame. The file will be saved in the sketch's folder.
    // The timestamp ensures that each saved file has a unique name.
    saveFrame("grid-######.png");
  }
}
