import 'dart:convert';

import 'package:scratch_collect/modules/shared/utils/api/api.dart';
import 'package:scratch_collect/modules/wallet/models/use_voucher_request.dart';
import 'package:scratch_collect/modules/wallet/models/wallet.model.dart';

class VoucherService {
  static VoucherService? _instance;

  factory VoucherService() => _instance ??= VoucherService._();

  VoucherService._();

  Future<Wallet> useCoupon(UseVoucherRequest request) async {
    var response =
        await Api().dio.post('/coupon/use', data: jsonEncode(request.toJson()));

    return Wallet.fromJson(response.data);
  }
}
