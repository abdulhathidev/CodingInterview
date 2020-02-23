using System;

namespace CodingInterview.MyLearnings
{
    /*  
    Tree Data structure
    -------------------
    Height             Root                  Levels
    0 <------------ (A) ------------------->   1    
                   / | \
                  /  |  \
    1 <------- (B)  (C)  (D)  ------------->   2
              /   \     / | \
             /     \   /  |  \
    2 <--- (E)    (F)(G) (H) (I) ---------->   3
                  / \     |
                 /   \    |
    3 <------- (J)   (K) (L)  ------------->   4
                |        / \  
                |       /   \
    4 <------- (M)     (N)  (O) ----------->   5

    1. Disjoint subsets are below the root node each subtree (B),(C) or (D)

    1. Root                                 - The very first node of the tree is root.
    2. Parent                               - The node is connected with very next descendent node using one edge
    3. Child                                - (E) and (F) are children of Parent node (B)
    4. Siblings                             - Sibling is children of same parent Ex: (G), (H) & (I) are siblings.
    5. Descendant’s                         - A node's child and their child's and their children are Descendant’s.
    6. Ancestors                            - A node's parent and their parent until root are ancestors.
    7. Degree of Node                       - The number of direct children of a node is degree Ex: Degree of(L) is 2
    8. Internal or NonLeaf or Nonterminal   - The nodes are having the children 
                                                are called NonLeaf or Internal or Nonterminal nodes.
    9. External or Leaf or Terminal         - The nodes are don’t have the children’s called 
                                                Leaf or External or Terminal nodes.
    10.Levels                               - Each stage of node's are levels
    11.Height                               - Counting connecting edges from root to leaf nodes are Hight
    12.Forest                               - A collection of trees is called Forest

  
    */
    public class Tree
    {

    }
}