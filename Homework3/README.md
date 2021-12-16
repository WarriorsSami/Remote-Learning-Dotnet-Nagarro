## Geometrix Conclusions

### List of altered classes:
- **GeometrixWithOcp**: Program, Triangle
- **GeometrixWithoutOcp**: Program, Triangle, ***GeometricShapes***

### Open-Closed Principle:
- **Pros**:
    - **Open for extension**: The classes can be extended without affecting the clients.
    - **Closed for modification**: The classes can be modified without affecting the clients.
    - **Enhances code reuseability**: The classes can be reused in other projects as we are using platform / environment / implementation-agnostic means of abstraction.
    - **Enhances maintainability**
    - **Enhances testability thanks to enabling loose coupling**
- **Cons**:
    - **Can increase code complexity as the abstraction hierarchy is becoming more and more fine-grained**

#### Notes: As scalability is a scenario related concern, one should decide whether to use OCP or not based on demanded requirements.