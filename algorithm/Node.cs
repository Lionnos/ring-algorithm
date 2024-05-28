namespace algorithm;

public class Node
{
    public int id { get; set; }
    public Node nextNode { get; set; }
    public bool isCoordinator { get; set; }
    public bool isActive { get; set; }

    public Node(int _id, bool _isActive = true)
    {
        id = _id;
        isCoordinator = false;
        isActive = _isActive;
    }

    /*
    public void StartElection()
    {
        List<int> electionids = new List<int>();
        Node currentNode = this;

        do
        {
            if (currentNode.isActive)
            {
                electionids.Add(currentNode.id);
            }
            currentNode = currentNode.nextNode;

        } while (currentNode.id != id);

        if (electionids.Count == 0)
        {
            Console.WriteLine("No active nodes available for election.");
            return;
        }

        int newCoordinatorid = electionids.Max();
        currentNode = this;

        do
        {
            if (currentNode.id == newCoordinatorid)
            {
                currentNode.isCoordinator = true;
                Console.WriteLine($"Node {currentNode.id} is elected as the new Coordinator.");

            }
            else
            {
                currentNode.isCoordinator = false;
            }
            currentNode = currentNode.nextNode;
        } while (currentNode.id != id);
    }
    */

}