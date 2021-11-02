using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class TreeNode<T>
    {

        private T _data;
        private TreeNode<T> _parent;
        private int _level;
        private List<TreeNode<T>> _children;

        public TreeNode(T data)
        {
            _data = data;
            _children = new List<TreeNode<T>>();
            _level = 0;
        }

        public TreeNode(T data, TreeNode<T> parent) : this(data)
        {
            _parent = parent;
            //  _level = _parent != null ? _parent.Level + 1 : 0;

            if (_parent != null)
            {
                _level = _parent.Level + 1;
                _parent.AddChild(this);

            }
            else
            {
                _level = 0;
            }
        }

        public int Level
        {

            get { return _level; }


        }

        public int Count { get { return _children.Count; } }



        public bool IsRoot()
        {

            if (_parent != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public bool IsLeaf { get { return _children.Count == 0; } }
        public T Data { get { return _data; } }
        public TreeNode<T> Parent
        {


            get { return _parent; }
            set
            {
                if (value != null)
                {
                    _parent = value;
                    _level = _parent.Level + 1;
                    _parent.AddChild(this);

                }

            }



        }

        public void SetParentNode(TreeNode<T> parent)
        {
            _parent = parent;
        }


        public TreeNode<T> this[int key]
        {
            get { return _children[key]; }
        }

        public void Clear()
        {
            _children.Clear();
        }
        //public bool HasParent()
        //{
        //    if (_parent._data == null)
        //    {
        //        return false;

        //    }

        //    return true;

        //}
        //private void AddParent()
        //{

        //    _parent._children.Add(this);

        //}


        public void AddChild(TreeNode<T> value)
        {

            _children.Add(value);
            value.SetParentNode(this);

            // value._parent = ;

            // return node;
        }

        public TreeNode<T> AddChild(T value)
        {
            TreeNode<T> node = new TreeNode<T>(value, this);
            _children.Add(node);

            return node;
        }

        public bool HasChild(T data)
        {
            return FindInChildren(data) != null;
        }

        public TreeNode<T> FindInChildren(T data)
        {
            int i = 0, l = Count;
            for (; i < l; ++i)
            {
                TreeNode<T> child = _children[i];
                if (child.Data.Equals(data)) return child;
            }

            return null;
        }
        public TreeNode<T> FindInChildren(int position)
        {

            TreeNode<T> child = _children[position];

            return child;
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return _children.Remove(node);
        }












        //private readonly T _data;
        //private readonly TreeNode<T> _parent;
        //private readonly int _level;
        //private readonly List<TreeNode<T>> _children;

        //public TreeNode(T data)
        //{
        //    _data = data;
        //    _children = new List<TreeNode<T>>();
        //    _level = 0;
        //}

        //public TreeNode(T data, TreeNode<T> parent) : this(data)
        //{
        //    _parent = parent;
        //    //  _level = _parent != null ? _parent.Level + 1 : 0;

        //    if (_parent != null)
        //    {
        //        _level = _parent.Level + 1;
        //        _parent.AddChild(this);

        //    }
        //    else
        //    {
        //        _level = 0;
        //    }
        //}

        //public int Level { get { return _level; } }
        //public int Count { get { return _children.Count; } }
        //public bool IsRoot { get { return _parent == null; } }
        //public bool IsLeaf { get { return _children.Count == 0; } }
        //public T Data { get { return _data; } }
        //public TreeNode<T> Parent { get { return _parent; } }

        //public TreeNode<T> this[int key]
        //{
        //    get { return _children[key]; }
        //}

        //public void Clear()
        //{
        //    _children.Clear();
        //}
        ////public bool HasParent()
        ////{
        ////    if (_parent._data == null)
        ////    {
        ////        return false;

        ////    }

        ////    return true;

        ////}
        ////private void AddParent()
        ////{

        ////    _parent._children.Add(this);

        ////}


        //public void AddChild(TreeNode<T> value)
        //{

        //    _children.Add(value);

        //    // return node;
        //}

        //public TreeNode<T> AddChild(T value)
        //{
        //    TreeNode<T> node = new TreeNode<T>(value, this);
        //    _children.Add(node);

        //    return node;
        //}

        //public bool HasChild(T data)
        //{
        //    return FindInChildren(data) != null;
        //}

        //public TreeNode<T> FindInChildren(T data)
        //{
            
        //    for (int i = 0; i < Count; ++i)
        //    {
        //        TreeNode<T> child = _children[i];
        //        if (child.Data.Equals(data)) return child;
        //    }

        //    return null;
        //}
        //public TreeNode<T> FindInChildren(int position)
        //{
 
        //    TreeNode<T> child = _children[position];
    
        //    return child;
        //}

        //public bool RemoveChild(TreeNode<T> node)
        //{
        //    return _children.Remove(node);
        //}

    }
}