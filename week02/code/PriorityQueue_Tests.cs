using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue one item and dequeue returns it
    // Expected Result: The item value returned
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueOne()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("item1", 5);
        var result = pq.Dequeue();
        Assert.AreEqual("item1", result);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities; dequeue returns highest priority first
    // Expected Result: Items returned in order of priority from high to low
    // Defect(s) Found: Dequeue did not return highest priority due to index error
    public void TestPriorityQueue_HighestPriorityDequeuedFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("medium", 5);
        pq.Enqueue("high", 10);
        Assert.AreEqual("high", pq.Dequeue());
        Assert.AreEqual("medium", pq.Dequeue());
        Assert.AreEqual("low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same highest priority; dequeue returns the earliest enqueued of that priority (FIFO)
    // Expected Result: Dequeue returns first enqueued among equal priority items
    // Defect(s) Found: Returns last enqueued among equal priority items
    public void TestPriorityQueue_SamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("first", 10);
        pq.Enqueue("second", 10);
        pq.Enqueue("third", 5);

        Assert.AreEqual("first", pq.Dequeue());
        Assert.AreEqual("second", pq.Dequeue());
        Assert.AreEqual("third", pq.Dequeue());
    }
}