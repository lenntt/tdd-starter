from result import do_something
import pytest

def test_result_is_aways_1():
    assert do_something() == 1

def test_just_fail():
    pytest.fail("This test is always failing")
