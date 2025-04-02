# azure-devops-mcp

The C# MCP server for Azure DevOps

---

## Getting Started

1. **Download Docker Desktop**
   - Ensure you have Docker Desktop installed on your machine.
2. **Switch to Windows Daemon**
   - Open Docker Desktop and switch to the Windows daemon.

## Development

1. **Clone the Repository**
   - Clone this repository to your local machine.
2. **Install the Content**
   - Install the necessary content and add it to your MCP client configuration.
3. **Open in Visual Studio**
   - Use the `open` command to open the project in Visual Studio.

## Running

You have two options for running the server and client:

1. **Run Separately**
   - You can run the server and client separately.
2. **Run Together**
   - Use the following command to run both the server and client together:
     ```bash
     docker-compose up --build
     ```
   - They will communicate via port 8080.

![image](https://github.com/user-attachments/assets/d73f5224-57d9-437f-af99-851f7d24feb6)


## Contributing

Contributions are welcomed! Please open a pull request against the `main` branch.

---

<!-- version: 2025-04
