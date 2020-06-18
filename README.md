# Seneca.EnvironmentVariables.ExIm
[![Build Status](https://dev.azure.com/eminencegrs/ExIm/_apis/build/status/Seneca.EnvironmentVariables.ExIm?branchName=develop)](https://dev.azure.com/eminencegrs/ExIm/_build/latest?definitionId=8&branchName=develop)

## Introduction

## Documentation

### The list of parameters:
| key                | Description                             | Possible Values      |
|--------------------|-----------------------------------------|----------------------|
| --task             |                                         | import; export       |
| --filename 		 | Path to the file for reading or writing |                      |
| --target           |                                         | machine; user        |

### Example:
ExIm.exe --task=export --target=user --filename=C:\exported_variables.json