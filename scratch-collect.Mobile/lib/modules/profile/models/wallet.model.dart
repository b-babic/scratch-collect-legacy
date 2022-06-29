class Wallet {
  int? id;
  late double balance;
  String? createdAt;
  String? updatedAt;
  int? userId;

  Wallet(
      {this.id,
      this.balance = 0.0,
      this.createdAt,
      this.updatedAt,
      this.userId});

  Wallet.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    balance = json['balance'] ?? 0.0;
    createdAt = json['createdAt'];
    updatedAt = json['updatedAt'];
    userId = json['userId'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['balance'] = balance;
    data['createdAt'] = createdAt;
    data['updatedAt'] = updatedAt;
    data['userId'] = userId;

    return data;
  }
}
