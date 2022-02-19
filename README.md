# Seneca.Imex
[![Build](https://github.com/eminencegrs/seneca-imex/actions/workflows/dotnet.yml/badge.svg?branch=develop)](https://github.com/eminencegrs/seneca-imex/actions/workflows/dotnet.yml)

## Introduction

## Documentation

### The list of parameters:
| key                | Description                             | Possible Values      |
|--------------------|-----------------------------------------|----------------------|
| --task             |                                         | import; export       |
| --filename 		 | Path to the file for reading or writing |                      |
| --target           |                                         | machine; user        |

### Example:
Seneca.Imex.exe --task=export --target=user --filename=C:\exported_variables.json