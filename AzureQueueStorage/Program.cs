using Azure.Storage.Queues;

string connectionString = "DefaultEndpointsProtocol=https;AccountName=anishstorage786;AccountKey=E0ShJ37KOKnzUF5p5ijvLKigF1Tm02OJPsKQ0UqA+ouiwPZ+LC0oMXt56Ky4Vg0dpaJdwiIA8UT++ASt4lT15Q==;EndpointSuffix=core.windows.net";
string queueName = "anishqueue";

sendMessage("Anish Test Message 1");
sendMessage("Anish 786 Test Message 2");

void sendMessage(string message)
{
    QueueClient queueClient = new QueueClient(connectionString, queueName);
    if (queueClient.Exists())
    {
        queueClient.SendMessage(message);
        Console.WriteLine("Message sent {0}", message);
    }
}

