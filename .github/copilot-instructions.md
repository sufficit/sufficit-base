# Copilot Instructions
<!-- Version: 2.0 -->

* code comments should always be in English;
* response to user queries should be in IDE current language;
* avoid to change code that was not related to the query;
* when agent has to change a method and it change the async status, the agent should update the method callers too;
* for extensions methods use always "source" as default parameter name
* use one file for each class
* for #regions tags: no blank lines between consecutive regions, but always add one blank line after #region opening and one blank line before #endregion closing

## #Region Formatting Rules

### Correct Format:#region Properties

    public string Name { get; set; }
    public int Age { get; set; }

#endregion
#region Methods

    public void DoSomething()
    {
        // implementation
    }

#endregion
### Incorrect Format:#region Properties
    public string Name { get; set; }
    public int Age { get; set; }
#endregion

#region Methods
    public void DoSomething()
    {
        // implementation
    }
#endregion