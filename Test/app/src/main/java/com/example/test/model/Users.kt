package com.example.test.model

import com.google.gson.annotations.SerializedName

data class Users(
    @SerializedName("id")var id: Int,
    @SerializedName("login") var login:String,
    @SerializedName("password") var password:String)
