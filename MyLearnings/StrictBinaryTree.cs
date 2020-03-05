using System;

namespace CodingInterview.MyLearnings
{
    /*
            ()
           /  \
         ()    ()
        /  \  
      ()    ()
        Strict/Proper/Complete Binary Tree
        ----------------------------------
        Strict Binary tree means a node should have either 0 or 2 children. 
            And it should not have 1 childern.

        1. If height given count min number of nodes in strict binary tree  : 2h+1
        2. If height given count max number of nodes in strict binary tree  : 2^(h+1) - 1
        3. If nodes are given count min number hight in strict binary tree  : Log(n+1) - 1
        4. If nodes are given count max number hight in strict binary tree  : (n-1)/2
        5. Count the internal nodes in strict binary tree  (i = internal)   : i = e - 1 
        6. Count the external nodes in strict binary tree  (e = external)   : e = i + 1 
    */
    public class StrictBinaryTree
    {

    }
}