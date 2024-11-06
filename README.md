# Seneca.Imex

It provides a mechanism for exporting and importing environment variables to and from JSON files, allowing users to save and restore environment variable settings.

### Statuses

[![Build](https://github.com/eminencegrs/seneca-imex/actions/workflows/dotnet.yml/badge.svg?branch=develop)](https://github.com/eminencegrs/seneca-imex/actions/workflows/dotnet.yml)

## Introduction

## Documentation

### The list of parameters:
| key                | Description                             | Possible Values      |
|--------------------|-----------------------------------------|----------------------|
| --task             | Specifies the operation the tool should perform. This option determines whether environment variables are imported from a JSON file or exported to a JSON file. | import; export       |
| --filename 		 | The path to the JSON file that will be read from or written to. For import tasks, this is the file containing environment variables to load; for export tasks, it is the destination file where current environment variables are saved. |                      |
| --target           | Defines the scope or location where environment variables should be applied or saved. This parameter can set variables at the user level or machine level, impacting which users have access to them. | machine; user        |

### Example:
```bash
Seneca.Imex.exe --task=export --target=user --filename=exported_variables.json
```
```bash
Seneca.Imex.exe --task=import --target=user --filename=variables_to_be_imported.json
```
