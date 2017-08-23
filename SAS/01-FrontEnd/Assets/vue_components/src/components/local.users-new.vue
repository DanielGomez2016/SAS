<template>
  <div>
    <input v-model="Id" type="hidden" name="Id">
    <div class="alert-container"></div>
      <div class="form-group">
        <label>Email</label>
        <input v-model="Email" type="email" class="form-control" name="Email">
        <span data-key="Email" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Nombre</label>
        <input v-model="Name" type="text" class="form-control" name="Name">
        <span data-key="Name" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Apellidos</label>
        <input v-model="LastName" type="text" class="form-control" name="LastName">
        <span data-key="LastName" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Password</label>
        <input v-model="Password" type="password" class="form-control" name="Password">
        <span data-key="Password" class="form-validation-failed"></span>
      </div>
      
      <div class="form-group">
        <label>Confirmar Password</label>
        <input v-model="ConfirmPassword" type="password" class="form-control" name="ConfirmPassword">
        <span data-key="ConfirmPassword" class="form-validation-failed"></span>
      </div>
      
  </div>
</template>

<script>
import icon from './global.icon.vue'
export default {
  components:{
    icon
  },
  data(){
    return{
    Id: 0,
    Email: '',
    Password: '',
    ConfirmPassword: '',
    Name: '',
    LastName: '',
    }
  },
  name: 'usersnew',
}
</script>