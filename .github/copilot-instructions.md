# Copilot Instructions
<!-- Version: 202507151230 -->

## Common Guidelines
* whenever you find a newer Copilot Instructions file, merge the Common Guidelines content and adjust the version;
* code comments should always be in English;
* response to user queries should be in IDE current language;
* avoid to change code that was not related to the query;
* when agent has to change a method and it change the async status, the agent should update the method callers too;
* for extensions methods use always "source" as default parameter name
* use one file for each class
* for #region tags: no blank lines between consecutive regions, but always add one blank line after region opening and one blank line before region closing
* do not try to build if you just changed the code comments or documentation files;
* **when making relevant code changes, always create or update internal documentation following the Internal Documentation Guidelines**;

## Public Documentation Guidelines
* for github repository readme.md files, use the following structure:
  - Title
  - About (description, etc.)
  - Features
  - Installation
  - Usage (always on separated readme file, one for each case; testing, etc.)
  - License
  - Support (development@sufficit.com.br, etc.)
  - Related (references, thanks, etc.)
	 
## Internal Documentation Guidelines
* **Directory**: `/Documentation`, use this directory to store internal documentation files;
* **File Name**: use the following format for internal documentation files: `YYYYMMDDHHMM-description.md`, like `202507151109-migration.md`;
* **Content**: include detailed information about the internal processes, architecture decisions, and other relevant information that can help developers understand the system better;
* **Trigger Events**: create documentation for the following relevant changes:
  - New API implementations or client implementations
  - Significant architecture changes or refactoring
  - Breaking changes or deprecation of methods
  - New features or service integrations
  - Complex bug fixes that require explanation
  - Performance optimizations or security improvements
  - Database schema changes or migration procedures