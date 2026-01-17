using System.Net.Quic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue and dequeue the highest priority item from this: Homework (2), Notes (1), Test (3)
    // Expected Result: Test, Homework, Notes
    // Defect(s) Found: The dequeue index needs to start at 0, and the dequeue didn't remove the item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        var homework = new PriorityItem("Homework", 2);
        var notes = new PriorityItem("Notes", 1);
        var test = new PriorityItem("Test", 3);

        PriorityItem[] expectedResult = [test, homework, notes];

        priorityQueue.Enqueue(homework.Value, homework.Priority);
        priorityQueue.Enqueue(notes.Value, notes.Priority);
        priorityQueue.Enqueue(test.Value, test.Priority);

        for (int i = 0; i < priorityQueue.Length; i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
        }
    }

    [TestMethod]
    // Scenario: Create a queue and dequeue the highest priority item nearest to the front of the queue from this: Homework (2), Notes (1), Meeting (3), Quiz (2), Test (3)
    // Expected Result: Meeting, Test, Homework, Quiz, Notes
    // Defect(s) Found: The equal to comparison was causing it to go to the last item with highest priority intsead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        var homework = new PriorityItem("Homework", 2);
        var notes = new PriorityItem("Notes", 1);
        var meeting = new PriorityItem("Meeting", 3);
        var quiz = new PriorityItem("Quiz", 2);
        var test = new PriorityItem("Test", 3);

        PriorityItem[] expectedResult = [meeting, test, homework, quiz, notes];

        priorityQueue.Enqueue(homework.Value, homework.Priority);
        priorityQueue.Enqueue(notes.Value, notes.Priority);
        priorityQueue.Enqueue(meeting.Value, meeting.Priority);
        priorityQueue.Enqueue(quiz.Value, quiz.Priority);
        priorityQueue.Enqueue(test.Value, test.Priority);

        for (int i = 0; i < priorityQueue.Length; i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, value);
        }
    }

    [TestMethod]
    // Scenario: Try to get a value from an empty queue.
    // Expected Result: The Exception should throw with the correct error message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("The Exception should have been thrown when dequeued.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("An unexpected exception of the type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}