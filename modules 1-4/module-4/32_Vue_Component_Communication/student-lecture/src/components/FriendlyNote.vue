<template>
    <section id="opening"> <!-- Template can only have one direct child -->
      <h1>{{headerMessage}}</h1>
      <p>
        Don't worry if you can't give great answers to all or even most of these. Aim for being able to
        successfully answer around 70% or less of the questions asked of you.
      </p>
      <p>Focus on conveying a good impression as someone responsible, competent, and able to learn and grow.</p>
      <p>Remember that people are looking for someone who is:</p>
      <ul>
        <li>
          <em>Professional</em>,
          <em>Responsible</em>, and
          <em>Reliable</em>
        </li>
        <li>
          Knows how to program enough to work without
          <em>constant</em> help (regular check-ins are normal and
          expected)
        </li>
        <li>Able and willing to continue to learn and grow</li>
      </ul>
    </section>
</template>

<script>
export default {
    props: ['headerMessage']
}
</script>