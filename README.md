# Software Design Patterns written in C#
 This repository aims to provide a comprehensive guide to software design patterns in C# programming language through practical examples. Whether you are a beginner or an experienced developer, understanding design patterns can greatly enhance your software development skills and help you build more scalable, maintainable, and efficient code.

# What are Design Patterns?
Design patterns are reusable solutions to common software design problems encountered during the development process. They are established best practices that encapsulate the experience of developers over time. 

# Patterns Included
This repository covers design patterns categorized into three main types: creational, structural, and behavioral patterns. Each pattern is explained with a code example to demonstrate its implementation.

## Creational Patterns
### Singleton Pattern
#### Naive Singleton
A Naive Singleton is a very simple, but loose implementation of a Singleton Pattern. Side effects can be caused in multi-threaded environments, because multiple threads may call the GetInstance() at the same time, which can cause the creation of multiple instances of the Singleton class (paradox). Therefore I would recommend not to use this implementation in complex  multiple threaded environments. 
- not safe in multi-threaded environment

#### Lazy Singleton
A simple implementation of a Singleton Pattern can be provided by a lazy object initialization. Lazy initialization of an object means that its creation is delayed until its first use. When an object of the Singleton class is created for the first time, 
- simple & performs well
- implicitly uses LazyThreadSafetyMode
  
#### Double Check Lock Singleton
This Singleton implementation provides the lazy object initialization via a  "double check lock".
- doesn't perform as well as Lazy Singleton
- can be used in multithreaded environments
- tries to be thread safe without having to remove a lock every time

#### Nested Singleton
In this Singleton implementation the instantiation of the object is triggered by the first reference to the static member of the nested class.
- implementation is completely lazy
- nested classes have access to the private members of the enclosing class, but in reverse not

#### Monobehaviour Singleton
A simple Singleton implemention is sometimes not suitable when working with MonoBehaviour classes. Monobehaviour Singleton need to be implemented as Generic Class, to enable the inheritance of Monobehaviour functions.
- inheritance of Monobehaviour functions

## Structural Patterns
## Behavioral Patterns
