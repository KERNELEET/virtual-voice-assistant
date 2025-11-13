<h1 align="center">Virtual Voice Assistance C# (Sarah)</h1>
<p align="center">
  <img src="https://github.com/user-attachments/assets/6de7799a-1b75-4f14-8bb9-b78c05df0275" alt="Voice Assistant GUI Screenshot" width="700" />
</p>

This is a **C#-based Voice Assistant Application** built using **Windows Forms and .NET Speech Libraries**.  
Developed as part of my **Object-Oriented Programming (OOP)** coursework, this project demonstrates the integration of **speech recognition**, **speech synthesis**, and **natural language processing** to create an interactive virtual assistant capable of understanding and responding to user commands.

---

## ✨ Project Highlights

The Virtual Voice Assistance aims to streamline user interactions by enabling hands-free execution of commands, making computing tasks more accessible and efficient.

### **Core Functionality:**

* **🎙️ Interactive Voice Control:** A comprehensive system for effortless command execution.
* **🗓️ Task & Time Management:** Check time/date and manage schedules.
* **🧮 Calculator Feature:** Perform basic mathematical operations purely by voice.
* **🌐 Web Navigation:** Launch specific websites like YouTube in the default browser.
* **☪️ Hijri Calendar Integration:** Provide the current date in both Gregorian and Hijri formats.
* **🛑 Application Control:** Use voice commands like "Stop listening" or "Goodbye Sarah" to manage the assistant's state.

---

## 🧱 Key Features

| Feature | Description |
| :--- | :--- |
| **Speech Recognition** | Uses `System.Speech.Recognition` to accurately process and interpret spoken commands. |
| **Speech Synthesis** | Utilizes `System.Speech.Synthesis` (`Sarah`) to provide spoken feedback and responses. |
| **Natural Language** | Designed for smooth, natural interactions through extensive `if-else` logic and grammar loading. |
| **Dynamic State** | Features an "in-focus" mode and a "listening" mode, requiring a "Wake up" command to re-engage. |
| **Extensible Commands** | Commands are loaded from a plain text file (`DefaultCommands.txt`), making it easy to add new commands. |

---

## 🛠️ Tools and Components

### **Technologies Used**

| Tool / Library | Purpose |
| :--- | :--- |
| **C# (C Sharp)** | The primary programming language. |
| **Windows Forms** | Used for creating the Graphical User Interface (GUI). |
| **`System.Speech`** | The core library for all voice-related operations (recognition & synthesis). |
| **`System.IO`** | For reading commands from the external `DefaultCommands.txt` file. |
| **`System.Globalization`** | Specifically used for the Hijri Calendar integration. |
| **`System.Diagnostics`** | Used to open external processes (e.g., launching web browsers). |

### **Code Structure**

| Component | Description |
| :--- | :--- |
| `SpeechRecognitionEngine _recognizer` | Handles the main voice command processing. |
| `SpeechSynthesizer Sarah` | The Text-to-Speech engine for all spoken output. |
| `startlistening` | A secondary engine to listen only for the "Wake up" command. |
| `Default_SpeechRecognized` | The main event handler for interpreting commands and taking action. |
| `PerformCalculation()` | A dedicated function to execute the mathematical logic based on `currentOperation`. |

---

## ⚙️ How to Run

### 1. Prerequisites  
* **Visual Studio** (2019 or newer is recommended).  
* **Target Framework:** .NET Framework (as typically used for C# Windows Forms).

### 2. Project Setup  
1.  Clone this repository to your local machine.
2.  Open the solution file (`WindowsFormsApp1.sln`) in Visual Studio.
3.  Ensure the `DefaultCommands.txt` file is present in the main directory (or adjust its path in `Form1_Load`).

### 3. Build and Run  
1.  **Build** the solution (Build > Build Solution).
2.  **Start** the application (Debug > Start Debugging or press F5).

💡 **Note:** The application requires a working microphone configured as the default audio input device.

---

## 💬 Available Voice Commands

The following commands are available as defined in the project's logic and the `DefaultCommands.txt` file:

| Category | Command | Action |
| :--- | :--- | :--- |
| **General** | "Hello" | Responds with a greeting. |
| | "How are you" | Reports working status. |
| | "Stop talking" | Cancels ongoing speech synthesis. |
| **Time/Date** | "What date is it today" | States the current Gregorian date. |
| | "What Islamic date is it today" | States the current Hijri (Islamic) date. |
| | "What time is it" | States the current time. |
| **Utility** | "Math" | Initiates the multi-step calculator sequence. |
| | "Open YouTube" | Launches YouTube in the default web browser. |
| **Control** | "Show commands" | Displays the available commands in the ListBox. |
| | "Stop listening" | Suspends the main recognition engine. |
| | "Wake up" | Re-activates the main recognition engine. |
| | "Goodbye Sarah" | Shuts down the application. |

---

## 🧠 Skills Demonstrated

* **C# Programming:** Application development using C# language features.
* **GUI Development:** Creating an application interface with Windows Forms.
* **Speech API Integration:** Expert use of the `System.Speech` namespaces.
* **Natural Language Logic:** Implementing state-based (multi-step) interactions (e.g., the Calculator).
* **External Process Control:** Launching websites and managing application flow.
* **File Handling:** Reading external resources (`.txt` files) to configure application behavior.

---

## 👤 Author

**Ahmed Hussain**  
**Instructor:** Sir Shahbaz

---

This project is a testament to the comprehensive learning environment at **SSUET** and a reflection of the collective effort and continuous journey toward technological excellence.
