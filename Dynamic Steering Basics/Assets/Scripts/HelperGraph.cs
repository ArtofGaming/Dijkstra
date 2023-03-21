using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperGraph
{
    List<Connection> mConnections;

    // an array of connections outgoing from the given node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public void Build()
    {
        // find all nodes in scene
        // iterate over the nodes
        //   create connection objects,
        //   stuff them in mConnections
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost = (((float)toNode.beggars.Length / (1f/2f)) + toNode.dirtiness);
                Connection c = new Connection(cost, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }
}