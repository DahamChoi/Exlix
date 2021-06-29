using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree<T> {
    private Tree Parent;
    private List<Tree<T>> Childrens = new List<Tree<T>>();

    public Tree(Tree parent = null) {
        Parent = parent;
    }

    public void AddChild(Tree<T> child) {
        Childrens.Add(child);
    }
}
