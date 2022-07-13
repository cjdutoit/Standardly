[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
---
![Banner](https://user-images.githubusercontent.com/797750/178721760-945dc9bf-288e-4799-9368-1b34666757be.png)
---
# Standardly - Your '[The Standard](https://github.com/hassanhabib/The-Standard)' compliant code generator

## What is it?
The Standardly Code Generator is a productivity tool to quickly generate code for standard things in the following catgegories: BROKERS, FOUNDATIONS, CONTROLLERS / EXPOSERS, ACCEPTANCE, BUILD and PROVISION.

## Install instructions
- Install the the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=cjdutoit.Standardly)
- Install the [GitHub CLI commands](https://cli.github.com/)
- Install the [CLI tools for Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## Who can use it?
The productivity tool is recommended for experienced developers.  If you can't write this code yourself, please invest the time first, to understand what it does, how to write the unit tests and follow the TDD process, naming conventions and things as defined in [The Standard](https://github.com/hassanhabib/The-Standard)

## What can it do?

### Multi-Project Template
The Visual Studio Extension will provide a Multi-Project template that can be used to quickly setup a Solution with all the projects you would need.  Simply search for Standardly or set the project filter to Standardly to find the project template.

![image](https://user-images.githubusercontent.com/797750/178697758-eaa57669-2dcf-4e6b-83de-d2b6c5bccf29.png)

Then add your Solution Name in the Project Name text box, check the "Place solution and projects in the same directory" to ensure the folder structure is correct and click on Create ...

![image](https://user-images.githubusercontent.com/797750/178701928-30836481-7d96-4f96-b628-2cd48df4576f.png)

... which will then create the following skeleton projects

![image](https://user-images.githubusercontent.com/797750/178698307-e2570c3e-9cda-4724-b3e6-2bf34be123a2.png)

These projects only have the bare minimum in terms of setup.  We will use the Code Generator to add code for each...


### Code Generator

The Code Generator support some configuration options that can be found in Visual Studio under TOOLS > OPTIONS > Standardly

![image](https://user-images.githubusercontent.com/797750/178706013-89d3364c-57bd-40fe-ae7b-bca5a83fc722.png)

The options help define some settings so that you would not need to repeatedly fill them out on the form.  
- General:  
  - EditorConfig => Adds a .editorconfig file to ensure coding styles ins consistent.  This will only be added if one does not exist and if the box is checked.
  - Gitignore => Adds a .gitignore file to the solution.  This will only be added if one does not exist and if the box is checked.
  - Lincense => Adds a license file to the solution.  This will only be added if one does not exist and if the box is checked.
  - Copyright => The copyright text. Default is MIT.  This will also be used in the .editorconfig
  - Default Base Branch => The name of your base branch e.g. main / master
  - Display Name =>  The name to use in the copyright
  - GitHub Username =>  The username that will be used to create branches
  
- Locations:  Names that will be used to build a folder convention for storing the files within the project.  This will help us adapt to potential changes in the future or this could also be used as a translation option for folder names if code needs to be scaffolded for a different language.

### Generating Code

A new button is added to the context menu in Solution Explorer.

![image](https://user-images.githubusercontent.com/797750/178709225-d1becbbe-87e6-4084-8ab5-a5713bde1dbd.png)

You can either click that button or use the keyboard shortcut Ctrl+Shift+F4 to get the the Code Generator.

- Search for the template you want
- Complete the required fields
- Generate the code
- Review the pull requests on GitHub

![image](https://user-images.githubusercontent.com/797750/178709474-f0f8f7c8-6919-4cc3-b479-64b4b9c2af61.png)

 ProTip! If you want to scaffold code that follows on other code sets, you could tandem the branch creation process by changing the Branch From from `main` to the last create branch name for that broker i.e. `users/cjdutoit/brokers-students-delete`.   The `users/cjdutoit/foundations-students-add` will then be branched of that instead of `main`
 
## How can you help?

If you enjoy using the extension, please give it a rating on the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=cjdutoit.CJduToit-Standardly).

Should you encounter bugs or if you have feature requests, head on over to the [GitHub repo](https://github.com/cjdutoit/standardly) to open an issue if one doesn't already exist.

Pull requests are also very welcome if you would like to help with bugs or new features that can benefit us all as a '[The Standard](https://github.com/hassanhabib/The-Standard)' community.
