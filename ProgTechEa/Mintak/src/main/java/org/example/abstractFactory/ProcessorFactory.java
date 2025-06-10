package org.example.abstractFactory;

public abstract class ProcessorFactory {
    abstract Processor createCpu();
    abstract Processor createGpu();
}
