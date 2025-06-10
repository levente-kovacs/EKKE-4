package org.example.abstractFactory;

public class AmdProcessor extends ProcessorFactory {
    @Override
    Processor createCpu() {
        return new Cpu("Amd Processor");
    }
    @Override
    Processor createGpu() {
        return new Gpu("Amd Processor");
    }
}
