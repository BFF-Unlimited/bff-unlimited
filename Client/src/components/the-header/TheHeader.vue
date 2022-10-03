<template>
  <header class="header">
    <div class="header-content">
      <h1>
        <span class="visually-hidden">{{ user?.activeVestiging.name }}</span>
        <img
          :src="user?.activeVestiging.logoUrl"
          :alt="`Logo van ${user?.activeVestiging.name}`"
          height="40"
          class="header-logo"
        />
      </h1>
      <nav class="header-nav">
        <ul class="header-nav-list">
          <li class="header-nav-item">
            <AppExpandible v-if="user?.groepen.length > 1">
              <template #buttonText>{{ user?.activeGroep.name }}</template>
              <template #content>
                <ul>
                  <li
                    v-for="({ groep }, index) in groepen"
                    :key="index"
                  >
                    {{ groep.name }}
                  </li>
                </ul>
              </template>
            </AppExpandible>
            <span v-else>{{ user?.groepen[0].name }}</span>
          </li>
          <li class="header-nav-item">
            {{ user?.userName }}
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>

<script setup>
import { ActiveUserModel } from '~~/src/models/user.model';

defineProps({
  user: {
    type: ActiveUserModel,
  },
});
</script>

<style src="./the-header.css" lang="postcss" />
