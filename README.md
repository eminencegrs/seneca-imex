# Seneca.Imex

It provides a mechanism for exporting and importing environment variables to and from JSON files, allowing users to save and restore environment variable settings.

### Statuses

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
```bash
Seneca.Imex.exe --task=export --target=user --filename=exported_variables.json
```
```bash
Seneca.Imex.exe --task=import --target=user --filename=variables_to_be_imported.json
```
