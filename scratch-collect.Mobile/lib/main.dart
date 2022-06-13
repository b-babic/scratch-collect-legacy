import 'package:flutter/material.dart';
import 'package:scratch_collect_mobile/modules/auth/Login.page.dart';
import 'package:scratch_collect_mobile/modules/auth/Register.page.dart';
import 'package:scratch_collect_mobile/modules/home/Home.page.dart';

void main() {
  runApp(const ScratchCollect());
}

final routes = <String, WidgetBuilder>{
  LoginPage.tag: (context) => const LoginPage(),
  RegisterPage.tag: (context) => const RegisterPage(),
  HomePage.tag: (context) => const HomePage(),
};

class ScratchCollect extends StatelessWidget {
  const ScratchCollect({Key? key}) : super(key: key);

  static const String _title = 'Scratch&Collect';

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: _title,
      home: const Scaffold(
        body: LoginPage(),
      ),
      routes: routes,
    );
  }
}
