using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }


    /*
     * Complete the 'reverse' function below.
     *
     * The function is expected to return an INTEGER_DOUBLY_LINKED_LIST.
     * The function accepts INTEGER_DOUBLY_LINKED_LIST llist as parameter.
     */

    /*
     * For your reference:
     *
     * DoublyLinkedListNode
     * {
     *     int data;
     *     DoublyLinkedListNode next;
     *     DoublyLinkedListNode prev;
     * }
     *
     */

    static DoublyLinkedListNode reverse(DoublyLinkedListNode llist)
    {
        // New Head
        DoublyLinkedListNode newHead = null;

        // Lets run thru the list
        DoublyLinkedListNode runNode = llist;

        while ( runNode != null)
        {
            // Create new node
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(runNode.data);
            newNode.next = newHead;

            // Update newHead
            newHead = newNode;

            // Reverse pointer
            if (newNode.next != null)
                newNode.next.prev = newNode;

            // Next node
            runNode = runNode.next;
        }

        return newHead;
    }


    static void Main(string[] args)
    {

        string filename = Directory.GetCurrentDirectory() + @"\output1.txt";
        TextWriter textWriter = new StreamWriter(filename, true);

        string inFileName = Directory.GetCurrentDirectory() + @"\testecase1.txt";
        StreamReader sr = new StreamReader(inFileName);

        int t = Convert.ToInt32(sr.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            DoublyLinkedList llist = new DoublyLinkedList();

            int llistCount = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(sr.ReadLine());
                llist.InsertNode(llistItem);
            }

            DoublyLinkedListNode llist1 = reverse(llist.head);

            PrintDoublyLinkedList(llist1, " ", textWriter);
            textWriter.WriteLine();
        }

        textWriter.Flush();
        textWriter.Close();
    }
}