# xUnit-Results-Demonstration

Provide a minimal working example of an issue I encountered in xUnit

## To reproduce

1. Clone the xUnit-Result-Demonstration repository
2. Examine ./src/xUnit-Result-Demonstration.Tests/TestResults.xml
    - The comment in the file is a placeholder for anything that makes the results file slightly longer than normal, for example: a long duration in running a particular test.
3. Run ./test.ps1
4. Examine ./src/xUnit-Result-Demonstration.Tests/TestResults.xml
    - Note how there is malformed XML at the end of the file.

## Expected Behaviour

If TestResults.xml is shorter than a previous xUnit run, the file should end at the closing XML tag, without leaving any text from the previous xUnit run in the TestResults.xml file.