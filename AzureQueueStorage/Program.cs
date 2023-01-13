using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=anishstorage786;AccountKey=E0ShJ37KOKnzUF5p5ijvLKigF1Tm02OJPsKQ0UqA+ouiwPZ+LC0oMXt56Ky4Vg0dpaJdwiIA8UT++ASt4lT15Q==;EndpointSuffix=core.windows.net";
string queueName = "anishqueue";

// Send Messages 
sendMessage("Anish Test Message 1");
sendMessage("Anish 786 Test Message 2");

//PeekMessage();

//ReceiveMessage();

// get queue lenght
int queueLen = GetQueueLength();
Console.WriteLine("Queue Length {0}", queueLen);

void sendMessage(string message)
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
        queueClient.SendMessage(message);
        Console.WriteLine("Message sent {0}", message);
    }
}

void PeekMessage()
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    int maxMessages = 10;

    if (queueClient.Exists())
    {
        PeekedMessage[] peekedMessages = queueClient.PeekMessages(maxMessages);
        Console.WriteLine("The messages in the queue");
        foreach (var message in peekedMessages)
        {
            Console.WriteLine(message.Body);
        }
    }
}

void ReceiveMessage()
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    int maxMessages = 10;

    QueueMessage[] queueMessages = queueClient.ReceiveMessages(maxMessages);
    Console.WriteLine("The messages in the queue are");
    foreach (var message in queueMessages)
    {
        Console.WriteLine(message.Body);
        queueClient.DeleteMessage(message.MessageId, message.PopReceipt);
    }
}

int GetQueueLength()
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
        QueueProperties queueProperties = queueClient.GetProperties();
        return queueProperties.ApproximateMessagesCount;
    }

    return 0;
}
