﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MijnElement
{
    public char data;
    public MijnElement next;
    public MijnElement prev;

    public MijnElement(char c)
    {
        this.data = c;
    }
}

public class MijnLinkedList
{
    public MijnElement sent;

    public MijnLinkedList() 
    { 
        sent = new MijnElement('\0');
        sent.next = sent;
        sent.prev = sent;
    }

    public void VoegIn(char c, MijnElement y)
    {
        MijnElement x = new MijnElement(c);
        x.next = y.next;
        x.prev = y;
        y.next.prev = x;
        y.next = x;
    }

    public void Verwijder(MijnElement x)
    {
        if (x != sent)
        {
            x.prev.next = x.next;
            x.next.prev = x.prev;
        }
    }
}

public class hi
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int i = 0;
        while (i < n) 
        { 
            string toetsaanslagen = Console.ReadLine();
            MijnLinkedList llist = new MijnLinkedList();
            MijnElement cursor = llist.sent;
            StringBuilder wachtwoord = new StringBuilder();
            for (int aanslag = 0; aanslag < toetsaanslagen.Length; aanslag++)
            { 
                switch (toetsaanslagen[aanslag])
                {
                    case '-':
                        llist.Verwijder(cursor);
                        if (cursor != llist.sent)
                        { cursor = cursor.prev; }
                        break;
                    case '<':
                        if (cursor != llist.sent)
                        { cursor = cursor.prev; }
                        break;
                    case '>':
                        if (cursor.next != llist.sent)
                        { cursor = cursor.next; }
                        break;
                    default:
                        llist.VoegIn(toetsaanslagen[aanslag], cursor);
                        if (cursor.next != llist.sent)
                        { cursor = cursor.next; }
                        break;
                }
            }
            MijnElement current = llist.sent.next;
            while (current != llist.sent)
            {
                wachtwoord.Append(current.data);
                current = current.next;
            }
            Console.WriteLine(wachtwoord.ToString());
            i++;
        }
    }
}