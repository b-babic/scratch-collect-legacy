import 'package:dio/dio.dart';

class BadRequestException extends DioError {
  BadRequestException(RequestOptions options, Response? response)
      : super(requestOptions: options, response: response);

  @override
  String toString() {
    if (response?.data != null) {
      return response?.data['Errors'][0];
    } else {
      return 'Invalid request';
    }
  }
}
