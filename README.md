# Seneca.EnvironmentVariables.ExIm
[![Build Status](https://eminencegrs.visualstudio.com/ExIm/_apis/build/status/Seneca.EnvironmentVariables.ExIm?branchName=master)](https://eminencegrs.visualstudio.com/ExIm/_build/latest?definitionId=8&branchName=master)

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