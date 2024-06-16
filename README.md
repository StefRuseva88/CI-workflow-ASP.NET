# "HouseRentingSystem" ASP.NET Core MVC app CI workflow 
## This is a test project for Back-End Test Automation March 2024 Course @ SoftUni
---
### Overview
This repository contains a ASP.NET Core MVC app app. The project focuses on building a CI workflow using GitHub Actions to automate testing of a pre-existing  application ("House Renting System").

### Project Goals:

- Implement a CI workflow in GitHub Actions.
- Configure the workflow to run tests on the "Student Registry" application.

### Prerequisites:

- Basic understanding of ASP.NET and testing frameworks.
- Familiarity with GitHub Actions.
  
### Setup:

1. **Clone this repository.**
2. **Restore dependencies.**

```sh
 dotnet restore
 dotnet build
 dotnet test
```

3. **(Optional) Review the existing "House Renting System" application code.**

### Running Tests:

The CI workflow is already defined in the .github/workflows directory. Pushing your code to the main branch will trigger the workflow automatically. The workflow will:

- Set up the environment.
- Install dependencies.
- Run tests for the "House Renting System" app.
### Additional Notes:

- This project serves as a demonstration of CI/CD concepts using a pre-existing application.
- The specific details of the "House Renting System" application are not covered in this repository.

### Contributing
Contributions are welcome! If you have any improvements or bug fixes, feel free to open a pull request.

### License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

### Contact
For any questions or suggestions, please open an issue in the repository.

