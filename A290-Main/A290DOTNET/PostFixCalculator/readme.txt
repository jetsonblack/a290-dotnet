# Post Fix Calculator - README
## Author
Jetson Black
## Date Created
December 5, 2024
## Last Modified
December 10, 2024
## Assignment
A290 - Homework 3 Project
---


## Design Choices

### Error Handling
- **Message Boxes:**  
  Updated message boxes to use **error formatting** when the user provides invalid input. This offers a clear distinction between errors and normal messages.

### Button Functionality
- **Accept and Cancel Buttons:**  
  - **Accept Button:** Mapped to the **AC (Clear)** button for quick form clearing.  
  - **Cancel Button:** Mapped to the **Quit** button for easy exit.

### Form Resizing
- **Fixed Size:**  
  Resizing is locked to maintain a consistent layout, respecting traditional calculator design conventions.

### Operator Placement
- **Binary Operators (+, -, *, /, ^):**  
  Placed after the second number input to implicitly indicate that binary operations require **two inputs**.
- **Unary Operators (Sin, Cos, Tan):**  
  Placed after the first number input, signaling their use with **single inputs**.

### User Interface Design
- **Color Scheme:**  
  - Implemented the **Solarized Dark** theme from (https://ethanschoonover.com/solarized/) for a sleek and professional look.
  - **Buttons and Textboxes** use various Solarized colors for clarity and distinction:
    - **Buttons:** Highlighted with `#fdf6e3` and styled flat for a modern feel.
    - **Quit Button:** Uses an **orange** color to emphasize its importance.
    - **All Clear (AC) Button:** Uses a **cyan** color to differentiate it.
    - **Result Textbox:** Styled with a **green** foreground (`#dcfc03`) to distinguish it from input fields.

- **Opacity:**  
  Form opacity is set to **95%** for a subtle transparency effect, enhancing the modern look.

### User Interaction Enhancements
- **Mouse Events:**  
  Clicking on input fields clears placeholder text for improved usability.
- **Hand Pointer Cursor:**  
  Used on clickable buttons to enhance user experience.

---

## How to Use the Application

1. **Input Numbers:**
   - Enter numbers in the **First Number** and **Second Number** fields.
   
2. **Perform Calculations:**
   - **Binary Operators:** Click `+`, `-`, `*`, `/`, or `^` after entering both numbers.
   - **Unary Operators:** Click `Sin`, `Cos`, or `Tan` after entering the first number. Use the **Radian Mode** checkbox to toggle between radians and degrees.

3. **Clear or Quit:**
   - Click **AC** to clear all fields.
   - Click **Quit** to exit the application.

---

## Features Summary

- **Fixed Window Size** to avoid layout distortion.
- **Error Handling** with clear feedback.
- **Solarized Dark Theme** for a polished look.
- **Accept and Cancel Buttons** mapped for efficiency.
- **Intuitive Placement** of operators for ease of use.

---
- [✔] **Address Design Goals**: Ensure the design meets the stated goals from Part I and any other relevant considerations.

- [✔] **README.TXT File**:  
  - [✔] Placed in the root project folder.  
  - [✔] Clearly explains design choices and how they are reflected in the final application.

- [✔] **Main Form**:  
  - [✔] Properly designed and functional main form interface.

- [✔] **Post-Fix Design**:  
  - [✔] No “=” sign.  
  - [✔] Two values entered.  
  - [✔] Function key generates result in the output field.

- [✔] **Data Entry Fields**:  
  - [✔] Two fields for data entry.

- [✔] **Result Field**:  
  - [✔] Display field for showing results.

- [✔] **Basic Arithmetic Functions**:  
  - [✔] Addition (+)  
  - [✔] Subtraction (-)  
  - [✔] Multiplication (*)  
  - [✔] Division (/)

- [✔] **NaN Check**:  
  - [✔] Routine to handle entries that are not numbers (NaN).  
  - [✔] Ensure proper error handling or feedback.

- [✔] **Additional Data Entry Checks**:  
  - [✔] Other checks to ensure user-friendly input validation.

- [✔] **Clear Data Fields Control**:  
  - [✔] Obvious way to clear data fields for a new calculation.

- [✔] **Additional Arithmetic/Mathematical Functions** (At least 4):  
  - [✔] Function 1: Exponential (^)  
  - [✔] Function 2: Sine Function (Sin) Both Radians and Degrees
  - [✔] Function 3: Cosine Function (Cos) Both Radians and Degrees
  - [✔] Function 4: Tangent Function (Tan) Both Radians and Degrees  

- [✔] **Clear Control**:  
  - [✔] Button or control to clear all fields and variables for a new calculation.

- [✔] **Quit Control**:  
  - [✔] Button or control to gracefully exit the application.

- [✔] **Code Comments**:  
  - [✔] General information/comments at the head of the code file.  
  - [✔] Inline comments explaining code functionality.
---
