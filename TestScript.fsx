#r @".\testType\SimpleStringProvider.dll"

open SimpleStringProvider

type x = SimpleStringProvider.SingleStringTypeProvider<"test">

x.