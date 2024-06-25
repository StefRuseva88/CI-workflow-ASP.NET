# CI workflow for "House Renting System" ASP.NET Core MVC app
![image](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![image](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![image](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![image](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)
### This is a test project for **Back-End Test Automation** March 2024 Course @ SoftUni
---
## Overview
This repository contains a ASP.NET Core MVC app app. The project focuses on building a CI workflow using GitHub Actions to automate testing of the application "House Renting System".

## Project Goals:

- Implement a CI workflow in GitHub Actions.
- Configure the workflow to run tests on the "House Renting Sysyem" application.

## Prerequisites:

- Basic understanding of ASP.NET and testing frameworks.
- Familiarity with GitHub Actions.
  
## Setup:
- Clone this repository.
- Restore dependencies, build the application and run tests:

```sh
 dotnet restore
 dotnet build
 dotnet test
```

- Review the existing "House Renting System" application code.

## Running Tests:

The CI workflow is already defined in the `.github/workflows directory`. Pushing your code to the main branch will trigger the workflow automatically. The workflow will:

- Set up the environment.
- Install dependencies.
- Run tests for the "House Renting System" app.
## Additional Notes:

- This project serves as a demonstration of CI/CD concepts using a pre-existing application.
- The specific details of the "House Renting System" application are not covered in this repository.

## Contributing
Contributions are welcome! If you have any improvements or bug fixes, feel free to open a pull request.

## License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or suggestions, please open an issue in the repository.

