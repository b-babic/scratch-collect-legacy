import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/auth/login.screen.dart';
import 'package:scratch_collect/modules/auth/signup.screen.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';
import 'package:scratch_collect/routes.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        pageTransitionsTheme: const PageTransitionsTheme(builders: {
          TargetPlatform.android: CupertinoPageTransitionsBuilder(),
        }),
      ),
      // home: SplashScreen(), TODO: Set splash as root once finished
      initialRoute: HomeScreen.routeName,
      routes: routes,
    );
  }
}
