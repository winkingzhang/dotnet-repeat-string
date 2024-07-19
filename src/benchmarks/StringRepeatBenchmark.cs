using BenchmarkDotNet.Attributes;
using org.zhangwenqing.stringutils;

[MemoryDiagnoser]
[ReturnValueValidator(failOnError: true)]
public class StringRepeatBenchmark
{
    [Params(
        "Hello World! ",
        "The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. "
    )]
    public string Source { get; set; } = string.Empty;

    [Params(1u, 10u, 100u, 1000u)] public uint N { get; set; }

    [Benchmark]
    public void RepeatByStringBuilder()
    {
        Source.RepeatByStringBuilder(N);
    }

    [Benchmark]
    public void RepeatByLinq()
    {
        Source.RepeatByLinq(N);
    }

    [Benchmark]
    public void RepeatByArray()
    {
        Source.RepeatByArray(N);
    }

    [Benchmark]
    public void RepeatByArrayFill()
    {
        Source.RepeatByArrayFill(N);
    }

    [Benchmark]
    public void RepeatBySpan()
    {
        Source.RepeatBySpan(N);
    }
}