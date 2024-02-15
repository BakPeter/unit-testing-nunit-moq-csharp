namespace TestNinja.UnitTests.Fundamentals;

[TestFixture]
public class StackTests
{
    private Stack<string> _stack;

    [SetUp]
    public void Setup()
    {
        _stack = new Stack<string>();
    }

    //[TearDown]
    //public void Teardown()
    //{
    //    _stack = null;
    //}

    [Test]
    public void Push_ItemIsValid_ItemsCountIncreaseBy1()
    {
        // Arrange
        var oldCount = _stack.Count;
        var item = "item";

        // Act
        _stack.Push(item);

        // Assert
        Assert.That(oldCount + 1, Is.EqualTo(_stack.Count));
    }

    [Test]
    public void Push_ItemIsNull_ThrowArgumentNullException()
    {
        // Arrange
        // Act

        // Assert
        Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
    }

    [Test]
    public void Pop_StackIsEmpty_ThrowInValidOperationException()
    {
        // Arrange
        // Act

        // Assert
        Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
    }

    [Test]
    public void Pop_WhenCalled_DecreaseItemsCountBy1AndReturnLastPushedItem()
    {
        // Arrange
        var item = "item";
        _stack.Push(item);
        var oldCount = _stack.Count;

        // Act
        var poppedItem = _stack.Pop();

        // Assert
        Assert.That(oldCount - 1, Is.EqualTo(_stack.Count));
        Assert.That(poppedItem, Is.EquivalentTo(item));
    }

    [Test]
    public void Peek_StackIsEmpty_ThrowInValidOperationException()
    {
        // Arrange
        // Act

        // Assert
        Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
    }

    [Test]
    public void Peek_WhenCalled_ReturnLastPushedItem()
    {
        // Arrange
        var item = "item";
        _stack.Push(item);

        // Act
        var peekedItem = _stack.Peek();

        // Assert
        Assert.That(peekedItem, Is.EquivalentTo(item));
    }

    [Test]
    public void Peek_WhenCalled_CountDontChanges()
    {
        // Arrange
        var item = "item";
        _stack.Push(item);
        var expectedCount = _stack.Count;

        // Act
        _stack.Peek();
        var result = _stack.Count;

        // Assert
        Assert.That(result, Is.EqualTo(expectedCount));
    }
}

public class Stack<T>
{
    private readonly List<T> _list = new();

    public int Count => _list.Count;

    public void Push(T item)
    {
        if (item is null) throw new ArgumentNullException();
        _list.Add(item);
    }

    public T Pop()
    {
        if (_list.Count == 0) throw new InvalidOperationException();

        var poppedItem = _list[Count - 1];
        _list.RemoveAt(Count - 1);
        return poppedItem;
    }

    public T Peek()
    {
        if (_list.Count == 0) throw new InvalidOperationException();
        return _list[Count - 1];
    }
}