<?php

require "result.php";

use PHPUnit\Framework\TestCase;

final class ResultTest extends TestCase
{
    public function testResultOf0ResultsIn0()
    {
        $this->assertEquals(0, result(0));
    }
}
