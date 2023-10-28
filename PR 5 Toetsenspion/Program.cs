using System;
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
        this.next = null;
        this.prev = null;
    }
}

public class MijnLinkedList
{
    public MijnElement sent;
    public MijnElement cursor;

    public MijnLinkedList() 
    { 
        sent = new MijnElement('\0');
    }

    public void VoegIn(MijnElement x, MijnElement y)
    {
            x.next = y.next;
            x.prev = y;
            if (x != sent)
            {
                y.next.prev = x;
                y.next = x;
            }
    }

    public void Verwijder(MijnElement x)
    {
        if (x != sent)
        {
            x.prev.next = x.next;
            x.next.prev = x.prev;
        }
    }

    public void left(MijnLinkedList list)
    {
        if (list.cursor != list.sent.next)
        { list.cursor = list.cursor.prev; }
    }

    public void right(MijnLinkedList list)
    {
        if (list.cursor != list.sent.prev)
        { list.cursor = list.cursor.next; }
    }

}

public class hi
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        MijnLinkedList llist = new MijnLinkedList();
        int i = 0;
        while (i < n) 
        { 
            string toetsaanslagen = Console.ReadLine();
            for (int aanslag = 0; aanslag < toetsaanslagen.Length; aanslag++)
            { 
                switch (toetsaanslagen[aanslag])
                {
                    case '-':
                        llist.Verwijder(llist.cursor.prev);
                        break;
                    case '<':
                        llist.left(llist);
                        break;
                    case '>':
                        llist.right(llist);
                        break;
                    default:
                        //llist.VoegIn(toetsaanslagen[aanslag], llist.cursor);
                        break;
                }
            }

            StringBuilder wachtwoord = new StringBuilder();
            //MijnElement current = head.next;
            /*while (current != tail) 
            { 
                wachtwoord.Append(current.c);
                current = current.next;
            }*/
            Console.WriteLine(wachtwoord);
            i++;
        }
    }
}