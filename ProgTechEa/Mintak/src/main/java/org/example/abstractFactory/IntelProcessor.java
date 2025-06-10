package org.example.abstractFactory;

public class IntelProcessor extends ProcessorFactory {
    @Override
    Processor createCpu() {
        return new Cpu("Intel Processor");
    }

    @Override
    Processor createGpu() {
        return new Gpu("Intel Processor");
    }
}
