namespace MicroFusion.DesingByContract.Tests;

[TestFixture]
public class ExceptionFactoryTests
{
    [Test]
    [TestCaseSource(nameof(CreateTestCases))]
    public void Create_ExceptionWithMessage_Success<T>(string partDefaultMessage,
        T value,
        string objectName,
        string customMessage,
        object? id,
        string valueName,
        string idName,
        string expectedMessage)
    {
        var exception = ExceptionFactory<Exception>.Create<T>(partDefaultMessage,
            objectName,
            customMessage,
            id,
            valueName,
            idName);

        exception.Should().BeOfType<Exception>();
        exception.Message.Should().Be(expectedMessage);
    }

    [Test]
    [TestCaseSource(nameof(CreateFail))]
    public void Create_ExceptionWithMessage_Fail<T>(string partDefaultMessage,
        T value,
        string objectName,
        string customMessage,
        object? id,
        string valueName,
        string idName,
        string expectedMessage)
    {
        var exception = () => ExceptionFactory<Exception>.Create<T>(partDefaultMessage,
            objectName,
            customMessage,
            id,
            valueName,
            idName);

        exception.Should()
            .Throw<ApplicationException>()
            .WithMessage("No passed default exception message.");
    }

    public static IEnumerable<TestCaseData> CreateTestCases
    {
        get
        {
            //valueName Tests
            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                null,// string valueName
                "Id",// string idName
                "String value in 'Customer' with 'Id: 555' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "",// string valueName
                "Id",// string idName
                "String value in 'Customer' with 'Id: 555' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                " ",// string valueName
                "Id",// string idName
                "String value in 'Customer' with 'Id: 555' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' in 'Customer' with 'Id: 555' should be empty.");// string expectedMessage

            //objectName Tests
            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                null,// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                " ",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                66,// string value
                " ",// string objectName
                null,// string customMessage
                555,// object? id
                "",// string valueName
                "Id",// string idName
                "Int32 value should be empty.");// string expectedMessage

            // IdName Tests
            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "",// string idName
                "'OrderId' in 'Customer' with 'ID: 555' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                " ",// string idName
                "'OrderId' in 'Customer' with 'ID: 555' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                null,// string idName
                "'OrderId' in 'Customer' with 'ID: 555' should be empty.");// string expectedMessage

            // id Tests
            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                null,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                "",// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                " ",// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "'OrderId' should be empty.");// string expectedMessage

            // value tests
            yield return new TestCaseData("should be empty",// string partDefaultMessage
                Guid.Empty,// string value
                "Customer",// string objectName
                null,// string customMessage
                55,// object? id
                null,// string valueName
                "Id",// string idName
                "Guid value in 'Customer' with 'Id: 55' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                5.5m,// string value
                "Customer",// string objectName
                null,// string customMessage
                55,// object? id
                null,// string valueName
                "Id",// string idName
                "Decimal value in 'Customer' with 'Id: 55' should be empty.");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                new object { },// string value
                "Customer",// string objectName
                null,// string customMessage
                55,// object? id
                null,// string valueName
                "Id",// string idName
                "Object value in 'Customer' with 'Id: 55' should be empty.");// string expectedMessage

            // CustomMessage tests
            yield return new TestCaseData("should be empty",// string partDefaultMessage
                new { },// string value
                "Customer",// string objectName
                "Custome message",// string customMessage
                55,// object? id
                null,// string valueName
                "Id",// string idName
                "Custome message");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                new { },// string value
                "Customer",// string objectName
                "",// string customMessage
                55,// object? id
                null,// string valueName
                "Id",// string idName
                "");// string expectedMessage

            yield return new TestCaseData("should be empty",// string partDefaultMessage
                new { },// string value
                "Customer",// string objectName
                "",// string customMessage
                55,// object? id
                null,// string valueName
                "Id",// string idName
                "");// string expectedMessage


        }
    }

    public static IEnumerable<TestCaseData> CreateFail
    {
        get
        {
            yield return new TestCaseData("",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "No passed default exception message.");// string expectedMessage

            yield return new TestCaseData(" ",// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "No passed default exception message.");// string expectedMessage

            yield return new TestCaseData(null,// string partDefaultMessage
                "Test value",// string value
                "Customer",// string objectName
                null,// string customMessage
                555,// object? id
                "OrderId",// string valueName
                "Id",// string idName
                "No passed default exception message.");// string expectedMessage
        }
    }
}

