﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    //durum yönetimi çok anlamadım
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            IState modified = new ModifiedState();
            modified.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            IState deleted = new DeletedState();
            deleted.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            IState added = new AddedState();
            added.DoAction(context);
            Console.WriteLine(context.GetState().ToString());


        }
    }


    interface IState
    {
        void DoAction(Context context);
    }

    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added!";
        }
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified!";
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Deleted!";
        }
    }

    

    class Context
    {
        IState _state;
        public void SetState(IState state) 
        {
            _state = state;
        }

        public IState GetState()
        { 
            return _state; 
        }
    }
}
